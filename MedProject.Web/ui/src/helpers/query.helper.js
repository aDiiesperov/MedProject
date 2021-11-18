export class QueryHelper {
  static updateQuery($route, $router, newParams) {
    let allParams = { ...$route.query, ...newParams };
    let newQuery = Object.keys(allParams)
      .filter((key) => {
        if (key === "") return false;
        if (allParams[key] instanceof Array) return allParams[key].length > 0;
        return allParams[key] !== "";
      })
      .map((key) => key + "=" + allParams[key])
      .join("&");
    $router.push(`?${newQuery}`);
  }
}
