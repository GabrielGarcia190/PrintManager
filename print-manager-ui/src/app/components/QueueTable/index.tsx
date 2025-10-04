'use client';
import { useFilesToPrint } from "@/app/hooks/useFilesToPrint";
import { FileItem } from "@/app/Types/FileItem";
import { PrinterIcon } from "@phosphor-icons/react";

const statusClasses: Record<FileItem["status"], string> = {
    "Pendente": "bg-warning-light/20 text-warning-light dark:bg-warning-light/20 dark:bg-warning-light/20",
    "Imprimindo": "bg-info-light/20 text-info-light dark:bg-info-dark/20 dark:text-info-dark",
    "Impresso": "bg-success-light/20 text-success-light dark:bg-success-dark/20 dark:text-success-dark"
};

export default function QueueTable() {
    const { files, loading, error } = useFilesToPrint();

    if (loading) {
        return (
            <div>
                <h2 className="text-2xl font-bold mb-4">Fila de Arquivos</h2>
                <p>Carregando arquivos...</p>
            </div>
        );
    }

    if (error) {
        return (
            <div>
                <h2 className="text-2xl font-bold mb-4">Fila de Arquivos</h2>
                <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded">
                    <strong>Erro:</strong> {error}
                </div>
            </div>
        );
    }

    if (files.length === 0) {
        return (
            <div>
                <h2 className="text-2xl font-bold mb-4">Fila de Arquivos</h2>
                <p>Nenhum arquivo encontrado na fila.</p>
            </div>
        );
    }

    return (
        <div>
            <h2 className="text-2xl font-bold mb-4">Fila de Arquivos</h2>
            <div className="overflow-x-auto bg-white dark:bg-gray-800 rounded-lg shadow-sm">
                <table className="w-full text-left">
                    <thead className="border-b border-border-light dark:border-border-dark">
                        <tr>
                            <th className="p-4 font-semibold">Nome do Arquivo</th>
                            <th className="p-4 font-semibold">Usuário</th>
                            <th className="p-4 font-semibold">Tamanho</th>
                            <th className="p-4 font-semibold">Status</th>
                            <th className="p-4 font-semibold text-right">Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {files.map((item, i) => (
                            <tr className="border-b border-border-light dark:border-border-dark" key={i}>
                                <td className="p-4">{item.nome}</td>
                                <td className="p-4 text-subtle-light dark:text-subtle-dark">{item.usuario}</td>
                                <td className="p-4 text-subtle-light dark:text-subtle-dark">{item.tamanho}</td>
                                <td className="p-4">
                                    <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${statusClasses[item.status]}`}>{item.status}</span>
                                </td>
                                <td className="p-4 text-right space-x-2">
                                    <button title="Imprimir agora"
                                        className="font-semibold bg-primary text-white rounded-md hover:underline p-2">
                                        <PrinterIcon size={24} />
                                    </button>
                                    <button className="font-semibold text-danger-light dark:text-danger-dark hover:underline">Cancelar</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}