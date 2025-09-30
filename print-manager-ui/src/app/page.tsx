import Footer from "./components/Footer";
import Header from "./components/Header";
import QueueTable from "./components/QueueTable";
import Sidebar from "./components/Sidebar";
import Status from "./components/Status";

export default function Home() {
  return (
    <div className="flex min-h-screen font-display bg-background-light dark:bg-background-dark text-foreground-light dark:text-foreground-dark">
      <Sidebar />
      <div className="flex-1 flex flex-col">
        <Header />
        <main className="flex-1 p-6 space-y-6">
          <Status />
          <QueueTable />
        </main>
        <Footer />
      </div>
    </div>
  );
}