import type EstadoMatricula from "../enums/EstadoMatricula";

export default interface Aluno {
    id: number;
    nome: string;
    telefone: string;
    email: string;
    estadoMatricula: EstadoMatricula;
    professorId: number;
}