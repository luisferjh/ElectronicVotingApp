<template>
 <span>
  <CounterResultsByCandidate/>
  <CounterResults/>
 </span>
</template>

<script>
  import CounterResults from '@/components/CounterResults'
  import CounterResultsByCandidate from '@/components/CounterResultByCandidate'
  export default {
      components: {
        CounterResults,
        CounterResultsByCandidate
      },
  }
</script>
