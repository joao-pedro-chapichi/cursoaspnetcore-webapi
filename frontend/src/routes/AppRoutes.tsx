import {
    createBrowserRouter,
    createRoutesFromElements,
    Route,
    RouterProvider,
} from "react-router";
import Layout from "../components/Layout/Layout";
import ListaAluno from "../pages/ListaAlunos";
import FormAluno from "../pages/FormAluno";

const router = createBrowserRouter(
    createRoutesFromElements(
        <>
        <Route path="" element={<Layout />}>
            <Route path="/lista_alunos" element={<ListaAluno/>}/>
            <Route path="/form_aluno/:alunoId" element={<FormAluno/>}/>    
        </Route>
        </>,
    ),
);

export default function AppRoutes() {
    return <RouterProvider router={router}/>;
}