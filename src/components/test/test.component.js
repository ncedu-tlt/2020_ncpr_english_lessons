import React from 'react';
import './test.component.less'
import {fromFetch} from "rxjs/fetch";
import {catchError, switchMap} from "rxjs/operators";
import {of} from "rxjs";

export default class TestComponent extends React.Component{

    response$;
    constructor(props) {
        super(props);
        this.showLanguages = this.showLanguages.bind(this);
        this.state = {
            items: []
        }
    }

    componentDidMount() {
        this.response$ = fromFetch('https://ncpr-2020-english-backend.herokuapp.com/api/languages')
            .pipe( switchMap(response => {
                    if(response.ok){
                        console.log('Done');
                        return response.json();
                    } else {
                        console.log('err');
                        return of({error: true, message: `Error ${response.status}`})
                    }
                }),
                catchError (err => {
                    console.error(err);
                    return of({error: true, message: err.message})
                })
            );
    }
    showLanguages(){
        this.response$.subscribe({
            next: result => {
                this.processRequest(result);
            },
            complete: () => console.log('Done')
        });
    }

    processRequest(result){
        this.setState({
            items:result
        });
    }


    render() {
        return (
            <div className="test-component__wrapper">
                <div className="test-component__title"> Доступные языки </div>
                <div className="test-component__langs">
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
                <button className="test-component__button" onClick={this.showLanguages}>Показать доступные языки</button>
            </div>
        );
    }
}
