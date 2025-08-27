import { Outlet } from "react-router";
import Header from "./Header";
import Sidebar from "./Sidebar";

export default function Layout() {
    return (
        <div className="flex h-screen w-screen">
            {}
            <Sidebar/>
            <div className="flex w-full flex-col bg-neutral-200">
                {}
                <Header/>
                {}
                <main className="h-full w-full p-4">
                    {}
                    <Outlet/>
                </main>
            </div>
        </div>
    );
}