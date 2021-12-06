import Vue from "vue";

Vue.filter("nullToDash", function (value) {
  return value === null || value === undefined || !value.toString().trim()
    ? "—"
    : value;
});
