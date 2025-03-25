import styles from '../css/Login.css';

function Login() {
    return (
        <div className="login-container">

            <div className="img-container">
                <img src="/IMG_0752.jpeg"></img>
            </div>

            <div className="login-container-form">
                <form className="form-container">
                    <input type="text" placeholder="E-mail" className="login-input"></input>
                    <input type="text" placeholder="Senha" className="login-input"></input>

                    <button type="submit" className="link-button login-button">Login</button>
                </form>
                <a href="" className="forgot-password">Esqueceu sua senha?</a>
            </div>
        </div>
    );
}

export default Login;