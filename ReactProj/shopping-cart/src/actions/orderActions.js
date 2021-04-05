import { CREATE_ORDER, CLEAR_CART, CLEAR_ORDER, FETCH_ORDERS } from "../type";

export const createOrder = (order) => (dispatch) => {  //建立訂單
    fetch("/api/orders", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(order),
    })
      .then((res) => res.json())
      .then((data) => {
        dispatch({ type: CREATE_ORDER, payload: data });
        localStorage.clear("cartItems");
        dispatch({ type: CLEAR_CART });
      });
  };
  export const clearOrder = () => (dispatch) => {  //清除訂單
    dispatch({ type: CLEAR_ORDER });
  };
  export const fetchOrders = () => (dispatch) => {  //取得訂單
    fetch("/api/orders")
      .then((res) => res.json())
      .then((data) => {
        dispatch({ type: FETCH_ORDERS, payload: data });
      });
  };