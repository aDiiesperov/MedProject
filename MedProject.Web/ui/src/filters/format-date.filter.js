import Vue from "vue";

Vue.filter("formatDate", function (value) {
  if (!value) return "";

  if (typeof value === "string") {
    value = new Date(value);
  }

  return value.toLocaleDateString();
});
