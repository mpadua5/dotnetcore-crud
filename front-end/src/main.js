import Vue from 'vue'
import "@/styles/global.css"
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import App from './App.vue'
import router from './Router'

Vue.config.productionTip = false

Vue.use(VueMaterial)

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');

