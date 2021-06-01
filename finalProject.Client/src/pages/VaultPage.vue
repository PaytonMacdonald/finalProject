<template>
  <div class="container-fluid mx-5">
    <div class="row mx-5 mt-5 d-flex align-items-center">
      <h1>Vault Name <i class="ml-3 fas fa-trash text-danger delete-button" /></h1>
    </div>
    <div class="row mx-5 mt-1 border-bottom border-primary pb-4">
      <h4>keeps: 0</h4>
    </div>
    <div class="row mx-5 mt-3">
      <KeepComponent />
    </div>
  </div>
</template>

<script>
import KeepComponent from '../components/KeepComponent'

export default {
  name: 'VaultPage',
  components: {
    KeepComponent
  }
}
// TODO functions
// Delete Vault
// Edit Vault
// Get VaultKeeps
</script>

<style scoped>
.delete-button:hover{
  opacity: 80%;
  cursor: pointer;
}
</style>
