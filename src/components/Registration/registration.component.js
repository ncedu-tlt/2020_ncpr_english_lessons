import React from "react";
import "./registration.component.scss"

class RegistrationComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
            <div className="registration-component__title">
                <h1>Регистрация</h1>
            </div>
                <p>
                    <label htmlFor="Имя пользователи" className="uname"> Введите электронную почту</label>
                    <input id="username" name="username" required="Обязательное" type="text"
                           placeholder="mymail@mail.com"/>
                </p>
                <p>
                    <label htmlFor="Пароль" className="youpasswd">Введите пароль</label>
                    <input id="password" name="password" required="Обязательное" type="password"
                           placeholder="Придумайте пароль"/>
                </p>
                <p>
                    <label htmlFor="Пароль" className="youpasswd">Введите пароль</label>
                    <input id="password" name="password" required="Обязательное" type="password"
                           placeholder="Повторите пароль"/>
                </p>
                <div className="test-component__button">
                <input type="submit" value="Создать" />
                </div>
            </div>

        );
    }
}

export default RegistrationComponent;