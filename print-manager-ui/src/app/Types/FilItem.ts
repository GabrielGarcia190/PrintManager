export interface FileItem {
  nome: string;
  usuario: string;
  tamanho: string;
  status: "Pendente" | "Imprimindo" | "Impresso";
}