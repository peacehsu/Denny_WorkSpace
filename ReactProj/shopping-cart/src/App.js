import React,{ useState } from 'react';
import {Route,Link, BrowserRouter} from "react-router-dom";
import { Provider } from "react-redux";
import AdminView from "./Views/AdminView";
import HomeView from "./Views/HomeView";
import store from "./store";

class App extends React.Component{
  render(){
    return(
      <Provider store={store}>
        <BrowserRouter>
          <div className="grid-container">
            <header>
              <Link to="/">React購物網站</Link>
              <Link to="/admin">管理</Link>
            </header>
            <main>
              <Route path="/admin" component={AdminView} />
              <Route path="/" component={HomeView} />
            </main>
            <footer>React練習</footer>
          </div>
        </BrowserRouter>
      </Provider>
    );
  }
}

export default App;
