import React from "react";

export default function Status() {
  return (
    <div className="bg-white dark:bg-background-dark/50 rounded-lg p-6 shadow-sm flex items-center justify-between">
      <div>
        <p className="text-sm text-subtle-light dark:text-subtle-dark">Status do Serviço</p>
        <p className="text-2xl font-bold text-success-light dark:text-success-dark flex items-center gap-2">
          <span className="material-symbols-outlined">check_circle</span> Running
        </p>
        <p className="text-sm text-subtle-light dark:text-subtle-dark">Última impressão: 09/07/2024 10:30 AM</p>
      </div>
    </div>
  );
}
