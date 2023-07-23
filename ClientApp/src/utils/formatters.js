export function formatDate(rawDate) {
  const date = new Date(rawDate)
  return `${date.getDate()}/${date.getMonth() +1 }/${date.getFullYear()}`
}

export function formatAddress({ cidade, estado, pais }) {
  return `${cidade}, ${estado} - ${pais}`
}