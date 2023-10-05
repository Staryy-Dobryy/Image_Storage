const PROXY_CONFIG = [
  {
    context: [
      "/Registration",
      "/Login",
      "/api/Publication",
      "/api/General"
    ],
    target: "https://localhost:7161",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
