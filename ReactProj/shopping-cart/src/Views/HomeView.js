import React, { Component } from "react";
import Filter from "../components/Filter";
import Products from "../components/Product";
import Cart from "../components/Cart";
export default class HomeView extends Component{
    render(){
        return (
            <div>
                <div className="content">
                    <div className="main">
                        <Filter></Filter>
                        <Products></Products>
                    </div>
                    <div className="sidebar">
                        <Cart/>
                    </div>
                </div>
            </div>
        );
    }
}