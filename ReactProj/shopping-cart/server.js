const express = require("express");
const mongoose = require("mongoose");
const shortid = require("shortid");
require('dotenv').config()

const app = express();
app.use(express.json());

app.use("/", express.static(__dirname + "/public"));
app.get("/", (req, res) => res.sendFile(__dirname + "/public/index.html"));

//建立MongoDB連線
mongoose.connect(
  process.env.MONGODB_URL || "mongodb://localhost/test",
  {
    useNewUrlParser: true,
    useCreateIndex: true,
    useUnifiedTopology: true,
  }
);

//建立Collection的Schema
const Product = mongoose.model(
  "products",
  new mongoose.Schema({
    _id: { type: String, default: shortid.generate },
    title: String,
    description: String,
    image: String,
    price: Number,
    availableSizes: [String],
  })
);

//取得所有產品
app.get("/api/products", async (req, res) => {
  const products = await Product.find({});
  res.send(products);
});

//儲存產品內容
app.post("/api/products", async (req, res) => {
  const newProduct = new Product(req.body);
  const savedProduct = await newProduct.save();
  res.send(savedProduct);
});

//依照id為條件刪除項目
app.delete("/api/products/:id", async (req, res) => {
  const deletedProduct = await Product.findByIdAndDelete(req.params.id);
  res.send(deletedProduct);
});

//建立Collection的Schema
const Order = mongoose.model(
  "order",
  new mongoose.Schema(
    {
      _id: {
        type: String,
        default: shortid.generate,
      },
      email: String,
      name: String,
      address: String,
      total: Number,
      cartItems: [
        {
          _id: String,
          title: String,
          price: Number,
          count: Number,
        },
      ],
    },
    {
      timestamps: true,
    }
  )
);

//寫入訂單內容
app.post("/api/orders", async (req, res) => {
  if (
    !req.body.name ||
    !req.body.email ||
    !req.body.address ||
    !req.body.total ||
    !req.body.cartItems
  ) {
    return res.send({ message: "Data is required." });
  }
  const order = await Order(req.body).save();
  res.send(order);
});

//取得所有訂單
app.get("/api/orders", async (req, res) => {
  const orders = await Order.find({});
  res.send(orders);
});

//依照id為條件刪除項目
app.delete("/api/orders/:id", async (req, res) => {
  const order = await Order.findByIdAndDelete(req.params.id);
  res.send(order);
});

const port = process.env.PORT || 5000;
app.listen(port, () => console.log("serve at http://localhost:5000"));