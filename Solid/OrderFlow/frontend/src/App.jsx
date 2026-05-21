import { useEffect, useState } from "react";
import axios from "axios";

function App() {

    // STATES

    const [users, setUsers] = useState([]);

    const [name, setName] = useState("");

    const [email, setEmail] = useState("");

    const [message, setMessage] = useState("");

    // URL API

    const api = "https://localhost:7243/api/User";

    // BUSCAR USUÁRIOS

    async function loadUsers() {

        try {

            const response = await axios.get(api);

            setUsers(response.data);

        } catch (error) {

            console.error(error);
        }
    }

    // CRIAR USUÁRIO

    async function createUser() {

        try {

            await axios.post(api, {
                name,
                email
            });

            // Mensagem sucesso
            setMessage("Usuário criado com sucesso!");

            // Limpar inputs
            setName("");
            setEmail("");

            // Atualizar tabela
            loadUsers();

        } catch (error) {

            console.error(error);
        }
    }

    // DELETAR USUÁRIO

    async function deleteUser(id) {

        try {

            await axios.delete(`${api}/${id}`);

            loadUsers();

        } catch (error) {

            console.error(error);
        }
    }

    // CARREGAR USUÁRIOS AO INICIAR

    useEffect(() => {

        async function fetchUsers() {

            await loadUsers();
        }

        fetchUsers();

    }, []);

    return (

        <div className="container mt-5">

            {/* TÍTULO */}

            <h1 className="text-center mb-5">
                OrderFlow - SOLID Architecture
            </h1>

            {/* SOLID CARDS */}

            <div className="row mb-5 justify-content-center">

                <div className="col-md-2 mb-3">
                    <div className="card p-3 shadow rounded text-center h-100">
                        <h5>SRP</h5>
                        <p>Responsabilidade única</p>
                    </div>
                </div>

                <div className="col-md-2 mb-3">
                    <div className="card p-3 shadow rounded text-center h-100">
                        <h5>DIP</h5>
                        <p>Inversão de dependência</p>
                    </div>
                </div>

                <div className="col-md-2 mb-3">
                    <div className="card p-3 shadow rounded text-center h-100">
                        <h5>ISP</h5>
                        <p>Interfaces segregadas</p>
                    </div>
                </div>

                <div className="col-md-2 mb-3">
                    <div className="card p-3 shadow rounded text-center h-100">
                        <h5>LSP</h5>
                        <p>Herança e abstração</p>
                    </div>
                </div>

                <div className="col-md-2 mb-3">
                    <div className="card p-3 shadow rounded text-center h-100">
                        <h5>OCP</h5>
                        <p>Aberto para extensão</p>
                    </div>
                </div>

            </div>

            {/* FORMULÁRIO */}

            <div className="card p-4 shadow rounded mb-5">

                <h3 className="text-center mb-4">
                    Criar Usuário
                </h3>

                {/* ALERTA */}

                {
                    message && (
                        <div className="alert alert-success">
                            {message}
                        </div>
                    )
                }

                {/* INPUT NOME */}

                <input
                    className="form-control mb-3"
                    placeholder="Nome"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />

                {/* INPUT EMAIL */}

                <input
                    className="form-control mb-3"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />

                {/* BOTÃO */}

                <button
                    className="btn btn-primary w-100"
                    onClick={createUser}
                >
                    Criar Usuário
                </button>

            </div>

            {/* TABELA */}

            <div className="card p-4 shadow rounded">

                <h3 className="text-center mb-4">
                    Usuários
                </h3>

                <table className="table table-striped table-hover">

                    <thead>

                        <tr>
                            <th>ID</th>
                            <th>Nome</th>
                            <th>Email</th>
                            <th>Ações</th>
                        </tr>

                    </thead>

                    <tbody>

                        {users.map(user => (

                            <tr key={user.id}>

                                <td>{user.id}</td>

                                <td>{user.name}</td>

                                <td>{user.email}</td>

                                <td>

                                    <button
                                        className="btn btn-danger btn-sm"
                                        onClick={() => deleteUser(user.id)}
                                    >
                                        Excluir
                                    </button>

                                </td>

                            </tr>

                        ))}

                    </tbody>

                </table>

            </div>

        </div>
    );
}

export default App;