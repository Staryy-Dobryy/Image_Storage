const PROXY_CONFIG = [
  {
    context: [
      "/api/Registration",
      "/api/Login",
      "/api/Publication",
      "/api/General",
      "/api/Gallery",
      "/api/GoogleAuth",
      "/api/Profile",
      "/api/Comment",
      "/Images/"
    ],
    target: "https://localhost:7161",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
