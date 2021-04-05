export const formatCurrency =(num) =>{
    if(num !==undefined){
        return "$"+Number(num.toFixed(1).toLocaleString()+" ");  //格式化價錢單位
    }
};
