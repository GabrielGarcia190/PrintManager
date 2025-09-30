export interface LogItem {
  time: string;
  text: string;
  type: "success" | "danger" | "info";
}