import React,{Component} from "react";
import {connect} from "react-redux";
import { formatCurrency } from "../unit";
import { fetchOrders } from "../actions/orderActions";

class Orders extends Component {
    componentDidMount() {
      this.props.fetchOrders();
    }
    render() {
      const { orders } = this.props;
      return !orders ? (
        <div>Orders</div>
      ) : (
        <div className="orders">
          <h2>訂單</h2>
          <table>
            <thead>
              <tr>
                <th>時間</th>
                <th>總計</th>
                <th>客戶姓名</th>
                <th>EMAIL</th>
                <th>地址</th>
                <th>項目</th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order) => (
                <tr>
                  <td>{order.createdAt}</td>
                  <td> {formatCurrency(order.total)}</td>
                  <td>{order.name}</td>
                  <td>{order.email}</td>
                  <td>{order.address}</td>
                  <td>
                    {order.cartItems.map((item) => (
                      <div>
                        {item.count} {" x "} {item.title}
                      </div>
                    ))}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  }
  export default connect(
    (state) => ({
      orders: state.order.orders,
    }),
    {
      fetchOrders,
    }
  )(Orders);