import { Timestamp } from "firebase/firestore";

export type FileStatus = "pending" | "printing" | "printed";

export interface FileItem {
  fileName: string;
  user: string;
  fileExtension: string;
  fileUrl: string;
  printerName: string;
  status: FileStatus;
  createdAt: Timestamp;
  updatedAt: Timestamp;
  errorMessage: string;
}
