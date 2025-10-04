'use client';
import { useEffect, useState } from "react";
import { collection, onSnapshot } from "firebase/firestore";
import { FileItem } from "@/app/Types/FileItem";
import { db } from "@/firebase/firebaseConfig";

export function useFilesToPrint() {
    const [files, setFiles] = useState<FileItem[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        // Verificar se estamos no cliente
        if (typeof window === 'undefined') {
            return;
        }

        try {
            const documents = collection(db, "FilesToPrint");

            const unsubscribe = onSnapshot(
                documents,
                (snapshot) => {
                    const docs: FileItem[] = snapshot.docs.map((doc) => {
                        const data = doc.data();

                        return {
                            id: doc.id,
                            nome: data.FileName || 'Nome não encontrado',
                            usuario: data.User || 'Usuário não encontrado',
                            tamanho: data.FileLenght || '0',
                            status: mapStatus(data.Status),
                        } as FileItem;
                    });

                    setFiles(docs);
                    setLoading(false);
                    setError(null);
                },
                (error) => {
                    console.error('Erro no Firebase:', error);
                    setError(error.message);
                    setLoading(false);
                }
            );

            return () => unsubscribe();
        } catch (error) {
            console.error('Erro ao configurar Firebase:', error);
            setError(error instanceof Error ? error.message : 'Erro desconhecido');
            setLoading(false);
        }
    }, []);

    function mapStatus(status: string): string {
        if (status == "1") return "Pendente";

        if (status == "2") return "Imprimindo";

        if (status == "3") return "Impresso";

        return status;
    };

    return { files, loading, error };
}