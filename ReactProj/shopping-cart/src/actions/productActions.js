import {FETCH_PRODUCTS} from "../type";
import {FILTER_PRODUCTS_BY_SIZE, ORDER_PRODUCTS_BY_PRICE} from "../type";

export const fetchProducts = () => async (dispatch) => {  //取得產品內容
    const res = await fetch("/api/products");
    const data = await res.json();
    console.log(data);
    dispatch({
      type: FETCH_PRODUCTS,
      payload: data,
    });
  };
  
export const filterProducts = (products, size) => (dispatch) => {  //篩選產品
    dispatch({
        type: FILTER_PRODUCTS_BY_SIZE,
        payload:{
            size: size,
            items:
                size === ""
                ? products
                : products.filter((x)=>x.availableSizes.indexOf(size) >=0),
        },
    });
};

export const sortProducts = (filteredProducts,sort) =>(dispatch) =>{  //項目排序
    const sortedProducts = filteredProducts.slice();
    if(sort ==="latest"){
        sortedProducts.sort((a, b) => (a._id > b._id ? 1 : -1));
    } else {
        sortedProducts.sort((a, b) =>
        sort === "lowest"
            ? a.price > b.price
            ? 1
            : -1
            : a.price > b.price
            ? -1
            : 1
        );
    }
    console.log(sortedProducts);
    dispatch({
        type: ORDER_PRODUCTS_BY_PRICE,
        payload: {
        sort: sort,
        items: sortedProducts,
        },
    });
};
