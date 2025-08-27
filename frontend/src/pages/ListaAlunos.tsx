import { useEffect, useState } from "react";
import axios from "axios";
import type Aluno from "../types/models/Aluno";
import EstadoMatricula from "../types/enums/EstadoMatricula";
import { useNavigate } from "react-router";

export default function ListaAluno() {
    const [alunos, setAlunos] = useState<Aluno[]>([]);
    const navigate = useNavigate();
    const estadosMatricula = {
        [EstadoMatricula.ATIVA]: "Ativa",
        [EstadoMatricula.SUSPENSA]: "Suspensa",
        [EstadoMatricula.CANCELADA]: "Cancelada",
    }

    const atualizarAluno = (id: number) => {
        navigate(`/form_aluno/${id}`);
    }

    const cadastrarAluno = () => {
        navigate("/form_aluno/0");
    }

    const excluirAluno = async (id: number) => {
        try {
            if (window.confirm(`Deseja deletar o aluno de id: ${id}?`)) {
                await axios.delete(`http://localhost:5119/api/v1/Aluno/${id}`);
                setAlunos(alunos.filter((aluno) => aluno.id != id));
            }
        } catch (error) {
            console.log(`Nao foi possivel excluir o aluno ${id}`, error);
        }
    };

    useEffect (() => {
        const getAlunos = async () => {
            try {
                const res = await axios.get("http://localhost:5119/api/v1/Aluno");
                console.log(res.data);

                const alunos: Aluno[] = res.data.data;
                setAlunos(alunos);
            } catch (error) {
                console.log(error);
            }
        };

        getAlunos();
    }, []);
    return (
        <div className="flex flex-col gap-4">
            <div className="flex justify-between">
                <h2 className="text-xl font-semibold">Gerenciamento de Alunos</h2>
                <button onClick={cadastrarAluno} className="cursor-pointer rounded-sm bg-green-600 px-2 py-1 text-white shadow-md">
                    Cadastrar Aluno
                </button>
            </div>

            <table className="w-full rounded-lg bg-neutral-300">
                <thead>
                    <tr className="h-12 text-left">
                        <th className="px-4">ID</th>
                        <th className="px-4">Nome</th>
                        <th className="px-4">Telefone</th>
                        <th className="px-4">Email</th>
                        <th className="px-4 text-center">Estado Matrícula</th>
                        <th className="px-4 text-center">Professor</th>
                        <th className="px-4 text-center">Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {alunos.map((aluno, index) => (
                        <tr key={aluno.id} className={`h-12 text-left ${index % 2 == 0 && "bg-neutral-200/50"}`}>
                            <td className="px-4">{aluno.id}</td>
                            <td className="px-4">{aluno.nome}</td>
                            <td className="px-4">{aluno.telefone}</td>
                            <td className="px-4">{aluno.email}</td>
                            <td className="px-4 text-center">
                                {estadosMatricula[aluno.estadoMatricula]}
                            </td>

                            <td className="px-4 text-center">{aluno.professorId}</td>
                            <td className="px-4">
                                <button onClick={() => atualizarAluno(aluno.id)} className="cursor-pointer rounded-sm bg-blue-400 px-2 py-1 text-white">
                                    Editar
                                </button>
                                <button onClick={() => excluirAluno(aluno.id)} className="ml-2 cursor-pointer rounded-sm bg-blue-500 px-2 py-1 text-white">
                                    Excluir
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}