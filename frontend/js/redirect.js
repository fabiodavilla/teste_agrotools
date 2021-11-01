const user = localStorage.getItem("logged");

if (user === null) {
  location.href = "login.html";
}
