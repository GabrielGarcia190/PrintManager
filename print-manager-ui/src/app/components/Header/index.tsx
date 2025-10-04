"use client";
import { db } from "@/firebase/firebaseConfig";
import { getDocs, collection } from "firebase/firestore";
import React from "react";

export default function Header() {

  const handleSync = async () => {
    try {
      const querySnapshot = await getDocs(collection(db, "printers"));
      const printers = querySnapshot.docs.map((doc) => ({
        id: doc.id,
        ...doc.data(),
      }));
      console.log("Dados sincronizados:", printers);
    } catch (error) {
      console.error("Erro ao sincronizar:", error);
    }
  };

  return (
    <header className="flex items-center justify-between border-b border-border-light dark:border-border-dark p-4">
      <div className="flex items-center gap-2">
        <span className="material-symbols-outlined text-primary text-2xl">print</span>
        <h1 className="text-xl font-bold">Painel de Impressão</h1>
      </div>
      <div className="flex items-center gap-4">
        <button onClick={handleSync}
          className="flex items-center gap-2 px-4 py-2 rounded-lg bg-primary text-white font-semibold hover:bg-primary/90 transition-colors">
          <span className="material-symbols-outlined">sync</span>
          <span>Sync</span>
        </button>
      </div>
    </header>
  );
}
