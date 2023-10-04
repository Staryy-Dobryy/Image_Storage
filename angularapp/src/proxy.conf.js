const PROXY_CONFIG = [
  {
    context: [
      "/Registration",
      "/Login",
      "/Publication"
    ],
    target: "https://localhost:7161",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
