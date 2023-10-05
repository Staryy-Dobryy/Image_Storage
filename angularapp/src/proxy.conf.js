const PROXY_CONFIG = [
  {
    context: [
      "/api/Registration",
      "/api/Login",
      "/api/Publication",
      "/api/General",
      "/api/GoogleAuth"
    ],
    target: "https://localhost:7161",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
