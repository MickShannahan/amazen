import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
const item1 = {
  name: 'item 1',
  price: 90,
  imgUrl: 'https://thiscatdoesnotexist.com',
  id: 1
}

const item2 = {
  name: 'item 2',
  price: 99,
  imgUrl: 'https://thiscatdoesnotexist.com',
  id: 12
}

const item3 = {
  name: 'item 3',
  price: 25,
  imgUrl: 'https://thiscatdoesnotexist.com',
  id: 123
}
export const AppState = reactive({
  user: {},
  account: {},
  activeMerchant: {},
  products: [item1, item2, item3]
})
