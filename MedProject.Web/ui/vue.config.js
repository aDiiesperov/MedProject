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
    resolve: {
      alias: {
        "@": path.resolve(__dirname, "./src"),
        "@components": path.resolve(__dirname, "./src/components"),
        "@store": path.resolve(__dirname, "./src/store"),
        "@services": path.resolve(__dirname, "./src/services"),
        "@helpers": path.resolve(__dirname, "./src/helpers"),
        "@views": path.resolve(__dirname, "./src/views"),
      },
      extensions: [".js", ".vue", ".json"],
    },
  },
};
