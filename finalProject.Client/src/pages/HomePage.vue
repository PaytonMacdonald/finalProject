<template>
  <div class="container-fluid mx-5 mt-4">
    <div class="row mx-5">
      <KeepComponent />
    </div>
  </div>
</template>

<script>
import KeepComponent from '../components/KeepComponent'
// import KeepComponent2 from '../components/KeepComponent2'
// import KeepComponent3 from '../components/KeepComponent3'

export default {
  name: 'HomePage',
  components: {
    KeepComponent
    // KeepComponent2,
    // KeepComponent3
  }
}
</script>

<style scoped>

</style>
