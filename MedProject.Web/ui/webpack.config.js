const webpack = require("webpack");
const path = require("path");
const { VueLoaderPlugin } = require("vue-loader");

const entriy = "src/main.js";
const dist = "../dist";

module.exports = {
  mode: "development",
  entry: path.resolve(__dirname, entriy),
  output: {
    path: path.resolve(__dirname, dist),
    filename: "vue.js",
    publicPath: "/dist/",
  },
  resolve: {
    alias: {
      "@": "/src",
    },
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: "vue-loader",
      },
      {
        test: /\.js$/,
        loader: "babel-loader",
      },
      {
        test: /\.css$/,
        use: ["vue-style-loader", "css-loader"],
      },
      {
        test: /\.(png|svg|jpg|jpeg|gif)$/i,
        type: "asset/resource",
      },
    ],
  },
  plugins: [
    new VueLoaderPlugin(),
    // TODO: investigate later how to declare .evn variables for webpack
    new webpack.DefinePlugin({
      "process.env.BASE_URL": "'/'",
    }),
  ],
};
