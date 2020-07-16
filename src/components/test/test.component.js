import React from "react";
import {fromFetch} from "rxjs/fetch";
import {catchError, switchMap} from "rxjs/operators";
import "./test.component.scss"

class TestComponent extends React.Component {

    response$;
    #PUBLIC_GATEWAY = "https://ncpr-2020-english-backend.herokuapp.com/";
    isShowLang = false;

    constructor(props) {
        super(props);
        this.state = {
            items: []
        };
        this.showLang = this.showLang.bind(this);
    }

    componentDidMount() {
        this.response$ = fromFetch(this.#PUBLIC_GATEWAY + "api/languages")
            .pipe(
                switchMap(response => {
                    if (response.ok) {
                        return response.json();
                    } else {
                        // Server is returning a status requiring the client to try something else.
                        console.error("Error during request: ", response.status)
                    }
                }),
                catchError(err => {
                    // Network or other error, handle appropriately
                    console.error(err);
                })
            );
    }

    showLang() {
        this.isShowLang = true;
        this.response$.subscribe({
            next: result => this.processRequest(result),
            complete: () => console.log("Done")
        });
    }

    processRequest(result) {
        this.setState({
            items: result
        })
    }


    render() {
        return (
            <div className="test-component__wrapper">
                <div className="test-component__title">
                    Доступные языки
                </div>
                <div className="test-component__list">
                    <ul>
                        {this.state.items.map(
                            item => (
                                <li key={item.languageId}>
                                    {item.title}
                                </li>
                            )
                        )}
                    </ul>
                </div>

                <button className={"test-component__button" + (this.isShowLang? '_hidden': '')} onClick={this.showLang}>Показать доступные языки</button>

            </div>
        );
    }

}

export default TestComponent;
