import { LogItem } from "@/app/Types/LogItem";
import React from "react";

const logs: LogItem[] = [
  { time: "10:30 AM", text: "File X printed successfully", type: "success" },
  { time: "10:20 AM", text: "Error printing Y", type: "danger" },
  { time: "10:15 AM", text: "File Z added to queue", type: "info" }
];

const colors: Record<LogItem["type"], string> = {
  success: "text-success-light",
  danger: "text-danger-light",
  info: "text-info-light"
};

export default function Sidebar() {
  return (
    <aside className="w-80 border-r border-border-light dark:border-border-dark bg-white dark:bg-background-dark flex flex-col">
      <div className="p-6">
        <h2 className="text-2xl font-bold">Logs</h2>
      </div>
      <div className="flex-1 overflow-y-auto">
        <div className="p-6 space-y-4">
          {logs.map((log, i) => (
            <div className="flex items-start gap-4" key={i}>
              <span className={`material-symbols-outlined ${colors[log.type]} mt-1`}>
                {log.type === "success" ? "check_circle" : log.type === "danger" ? "error" : "info"}
              </span>
              <div>
                <p className="font-semibold">{log.time}</p>
                <p className="text-sm text-subtle-light dark:text-subtle-dark">{log.text}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </aside>
  );
}
