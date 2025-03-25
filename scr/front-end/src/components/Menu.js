import styles from '../css/Menu.css';

function Menu() {
    return (
        <header className="header-container">
            <div className="logo-container">
                <a href="/"><img src="/drjose.png" className="logo"></img></a>
            </div>

            <nav className="nav-container">
                <ul className="menu-links">
                    <li className="menu-link">Home</li>
                    <li className="menu-link">A Clínica</li>
                    <li className="menu-link">Tratamentos</li>
                    <li className="menu-link">Testemunhas</li>
                    <li className="menu-link">Contato</li>
                </ul>
            </nav>

            <div className="buttons-container">
                <a href="" className="link-button appointment-link">Marque sua consulta</a>
                <a href="/login" className="link-button">Login</a>
                <a href="" className="link-button">Cadastro</a>
            </div>
        </header>
    );
}

export default Menu;