import { CREATE_ORDER, CLEAR_ORDER, FETCH_ORDERS } from "../type";

const orderReducer = (state = {}, action) => {
  switch (action.type) {
    case CREATE_ORDER:  //建立訂單
      return { order: action.payload };
    case CLEAR_ORDER:  //清除訂單內容
      return { order: null };
    case FETCH_ORDERS:  //篩選訂單
      return { orders: action.payload };
    default:
      return state;
  }
};
export { orderReducer };