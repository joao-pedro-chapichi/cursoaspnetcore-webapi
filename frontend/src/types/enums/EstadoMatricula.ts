const EstadoMatricula = {
    ATIVA: 1,
    SUSPENSA: 2,
    CANCELADA: 3
} as const;

type EstadoMatricula = (typeof EstadoMatricula)[keyof typeof EstadoMatricula];

export default EstadoMatricula;