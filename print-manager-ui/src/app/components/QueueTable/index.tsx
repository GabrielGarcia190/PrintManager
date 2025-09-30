import { FileItem } from "@/app/Types/FilItem";
import React from "react";

const filaArquivos: FileItem[] = [
    { nome: "Documento A.pdf", usuario: "Ethan Carter", tamanho: "2MB", status: "Pendente" },
    { nome: "Relatório B.docx", usuario: "Olivia Bennett", tamanho: "5MB", status: "Imprimindo" },
    { nome: "Fatura C.xlsx", usuario: "Liam Harper", tamanho: "1MB", status: "Impresso" }
];

const statusClasses: Record<FileItem["status"], string> = {
    "Pendente": "bg-warning-light/20 text-warning-light dark:bg-warning-dark/20 dark:text-warning-dark",
    "Imprimindo": "bg-info-light/20 text-info-light dark:bg-info-dark/20 dark:text-info-dark",
    "Impresso": "bg-success-light/20 text-success-light dark:bg-success-dark/20 dark:text-success-dark"
};

export default function QueueTable() {
    return (
        <div>
            <h2 className="text-2xl font-bold mb-4">Fila de Arquivos</h2>
            <div className="overflow-x-auto bg-white dark:bg-background-dark/50 rounded-lg shadow-sm">
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
                        {filaArquivos.map((item, i) => (
                            <tr className="border-b border-border-light dark:border-border-dark" key={i}>
                                <td className="p-4">{item.nome}</td>
                                <td className="p-4 text-subtle-light dark:text-subtle-dark">{item.usuario}</td>
                                <td className="p-4 text-subtle-light dark:text-subtle-dark">{item.tamanho}</td>
                                <td className="p-4">
                                    <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${statusClasses[item.status]}`}>{item.status}</span>
                                </td>
                                <td className="p-4 text-right space-x-2">
                                    <button className="font-semibold text-primary hover:underline">Imprimir agora</button>
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
