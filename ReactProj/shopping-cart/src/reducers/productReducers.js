import {
    FETCH_PRODUCTS,
    FILTER_PRODUCTS_BY_SIZE,
    ORDER_PRODUCTS_BY_PRICE,
  } from "../type";
  
  export const productsReducer = (state = {}, action) => {
    switch (action.type) {
      case FILTER_PRODUCTS_BY_SIZE:  //依照尺寸篩選
        return {
          ...state,
          size: action.payload.size,
          filteredItems: action.payload.items,
        };
      case ORDER_PRODUCTS_BY_PRICE:  //依照價錢排序
        return {
          ...state,
          sort: action.payload.sort,
          filteredItems: action.payload.items,
        };
      case FETCH_PRODUCTS:  //取得產品
        return { items: action.payload, filteredItems: action.payload };
      default:
        return state;
    }
  };