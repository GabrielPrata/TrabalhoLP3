export function urlBase () {
    return "https://localhost:7087/";
  if(window.location.href.includes("localhost")){
      // return "http://127.0.0.1:5000/"
      return "https://localhost:7087"
  }else if (window.location.href.includes("dev")){
      return "https://localhost:7087"
  } else {
      return "https://localhost:7087"
  }
}