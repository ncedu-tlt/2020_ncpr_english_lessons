import React from "react";
import "./authorization.component.scss"

class AuthorizationComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <div className="authorization-component__title">
                <h1>Вход</h1>
                </div>
                <div className="authorization-component__text">
                <p>
                    <label htmlFor="Имя пользователи" className="uname"> Введите электронную почту</label>
                    <input id="username" name="username" required="Обязательное" type="text"
                           placeholder="mymail@mail.com"/>
                </p>
                <p>
                    <label htmlFor="Пароль" className="youpasswd">Введите пароль</label>
                    <input id="password" name="password" required="Обязательное" type="password"/>
                </p>
                </div>
                <div className="authorization-component__button">
                <p><input type="submit" value="Вход" />
                <input type="submit" value="Регистрация" /></p>
                <p><input type="submit" value="Забыли пароль?" /></p>
                </div>
            </div>
        );
    }
}

export default AuthorizationComponent;