import React from "react";
import {fromFetch} from "rxjs/fetch";
import {catchError, switchMap} from "rxjs/operators";
import "./test.component.scss"
import { BrowserRouter } from "react-router-dom";

class TestComponent extends React.Component {

    #PUBLIC_GATEWAY = "https://ncpr-2020-english-backend.herokuapp.com/";

    constructor(props) {
        super(props);
        this.state = {
            items: []
        };
    }

    componentDidMount() {
        fromFetch(this.#PUBLIC_GATEWAY + "api/languages")
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
            ).subscribe({
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
                    <div className="test-component__list" onLoad={setTimeout(this.showLang,5000)}>
                        <select className={"test-component__selection" + (this.isShowLang? '_hidden': '')} >
                            <option></option>
                            {this.state.items.map(
                                item => (
                                    <option key={item.languageId}>
                                        {item.title}
                                    </option>
                                )
                            )}
                        </select>
                    </div>
                </div>
        );
    }

}

export default TestComponent;
