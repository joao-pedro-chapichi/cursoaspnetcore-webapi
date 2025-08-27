export default function Sidebar() {
    return (
        <nav className="flex h-full w-64 flex-col bg-blue-500 text-white">
            <h1 className="mx-auto my-4 text-xl font-semibold select-none">
                StudentManager
            </h1>
            <div className="flex w-full flex-col">
                <button className="flex w-full cursor-pointer items-start px-4 py-2 transition-colors hover:bg-blue-400">
                    Gerenciar Alunos
                </button>
                <button className="flex w-full cursor-pointer items-start px-4 py-2 transition-colors hover:bg-blue-400">
                    Gerenciar Professores
                </button>
            </div>
        </nav>
    );
}