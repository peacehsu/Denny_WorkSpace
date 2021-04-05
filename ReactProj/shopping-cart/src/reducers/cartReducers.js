import { ADD_TO_CART, REMOVE_FROM_CART } from "../type";

export const cartReducer = (
  state = { cartItems: JSON.parse(localStorage.getItem("cartItems") || "[]") },
  action
) => {
  switch (action.type) {
    case ADD_TO_CART:  //加入購物車
      return { cartItems: action.payload.cartItems };
    case REMOVE_FROM_CART: //刪除購物車項目
      return { cartItems: action.payload.cartItems };
    default:
      return state;
  }
};