import { collection, getDocs } from "firebase/firestore";
import { FileItem } from "@/app/Types/FileItem";
import { db } from "./config";

export async function getFileQueue(): Promise<FileItem[]> {
  const querySnapshot = await getDocs(collection(db, "printJobs"));

  return querySnapshot.docs.map((doc) => {
    const data = doc.data();
    return {
      ...data,
      createdAt: data.createdAt,
      updatedAt: data.updatedAt,
    } as FileItem;
  });
}
