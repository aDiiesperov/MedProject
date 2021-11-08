const path = require("path");

module.exports = {
  outputDir: path.resolve(__dirname, "../dist"),
  publicPath: "/dist/",
  lintOnSave: false,
  productionSourceMap: false,
  filenameHashing: false,
  css: {
    extract: {
      filename: "css/vue.css",
    },
  },
  configureWebpack: {
    optimization: {
      splitChunks: false,
    },
    output: {
      filename: "js/vue.js",
    },
  },
};
