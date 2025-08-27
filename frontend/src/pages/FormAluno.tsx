import { useEffect, useState, type FormEvent } from "react";
import axios from "axios";
import EstadoMatricula from "../types/enums/EstadoMatricula";
import { useNavigate, useParams } from "react-router";
import type Aluno from "../types/models/Aluno";
import type Professor from "../types/models/Professor";

export default function FormAluno() {
    const [nome, setNome] = useState<string>("");
    const [telefone, setTelefone] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [estadoMatricula, setEstadoMatricula] = useState<EstadoMatricula>(EstadoMatricula.ATIVA);
    const [professorId, setProfessorId] = useState<number>(1);

    const [professores, setProfessores] = useState<Professor[]>([]);

    const navigate = useNavigate();
    const { alunoId } = useParams();

    useEffect(() => {
        const getAluno = async () => {
            try {
                const res = await axios.get(
                    `http://localhost:5119/api/v1/Aluno/${alunoId}`,
                );
                const aluno: Aluno = res.data.data;
                setNome(aluno.nome);
                setTelefone(aluno.telefone);
                setEmail(aluno.email);
                setEstadoMatricula(aluno.estadoMatricula);
                setProfessorId(aluno.professorId);
            } catch (error) {
                console.log(error);
            }
        };

        const getProfessores = async () => {
            try {
                const res = await axios.get(`http://localhost:5119/api/v1/Professor`);
                const professores: Professor[] = res.data.data;
                setProfessores(professores);
            } catch (error) {
                console.log(error);
            }
        };

        getProfessores();

        if (alunoId == "0") return;
        else getAluno();
    }, [alunoId]);

    const cadastrarOuAtualizar = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        const aluno: Aluno = {
            id: 0,
            nome,
            telefone,
            email,
            estadoMatricula,
            professorId
        };

        try {
            if (alunoId && alunoId != "0") {
                aluno.id = Number(alunoId);
                await axios.put(`http://localhost:5119/api/v1/Aluno/${alunoId}`, aluno);
            } else {
                await axios.post("http://localhost:5119/api/v1/Aluno", aluno);
            }

            navigate("/lista_alunos");
        } catch (error) {
            alert("Erro ao salvar " + error);
        }
    };

    return (
        <div className="flex h-full items-center justify-center gap-4">
            <form onSubmit={cadastrarOuAtualizar} className="flex w-96 flex-col itens-center justify-center rounded-lg bg-neutral-100 p-4 shadow-md">
                <h3 className="mb-4 text-xl font-semibold">Fomulário Aluno</h3>
                <label className="w-full" htmlFor="nome">
                    Nome
                </label>
                <input id="nome" type="text" value={nome} onChange={(e) => setNome(e.target.value)} required className="mb-2 w-full rounded-sm bg-neutral-200 px-4 py-2 text-neutral-700 outline-none" />

                <label className="w-full" htmlFor="telefone">
                    Telefone
                </label>
                <input id="telefone" type="text" value={telefone} onChange={(e) => setTelefone(e.target.value)} required className="mb-2 w-full rounded-sm bg-neutral-200 px-4 py-2 text-neutral-700 outline-none" />

                <label className="w-full" htmlFor="email">
                    Email
                </label>
                <input id="email" type="email" value={email} onChange={(e) => setEmail(e.target.value)} required className="mb-2 w-full rounded-sm bg-neutral-200 px-4 py-2 text-neutral-700 outline-none" />

                <div className="mb-2 flex gap-4">
                    <div className="w-[50%]">
                        <label className="w-full" htmlFor="matricula">
                            Matrícula
                        </label>
                        <select id="matricula" value={estadoMatricula} onChange={(e) => setEstadoMatricula(Number(e.target.value) as EstadoMatricula)} className="mb-2 w-full rounded-sm bg-neutral-200 px-4 py-2 text-neutral-700 outline-none">
                            { }
                            {Object.keys(EstadoMatricula).map((opcao) => (
                                <option key={opcao} value={EstadoMatricula[opcao as keyof typeof EstadoMatricula]}>{opcao}</option>
                            ))}
                        </select>
                    </div>
                    <div className="w-[50%]">
                        <label htmlFor="professor" className="w-full">
                            Professor
                        </label>
                        <select id="professor" className="w-full rounded-sm bg-neutral-200 px-4 py-2 text-neutral-700 outline-none" value={professorId} onChange={(e) => setProfessorId(Number(e.target.value))}>
                            {professores.map((professor) => (
                                <option key={professor.id} value={professor.id}>
                                    {professor.nome}
                                </option>
                            ))}
                        </select>
                    </div>
                </div>

                <button type="submit" className="w-fit cursor-pointer rounded-sm bg-blue-500 px-2 py-1 text-white">
                    Enviar
                </button>
            </form>
        </div>
    );
}