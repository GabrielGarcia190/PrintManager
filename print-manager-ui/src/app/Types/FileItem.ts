import { Timestamp } from "firebase/firestore";

export type FileStatus = "Pendente" | "Imprimindo" | "Impresso";

export interface FileItem {
  id?: string;
  nome: string;
  usuario: string;
  tamanho: string;
  status: FileStatus;
  fileName?: string;
  user?: string;
  fileExtension?: string;
  fileUrl?: string;
  printerName?: string;
  createdAt?: Timestamp;
  updatedAt?: Timestamp;
  errorMessage?: string;
}
