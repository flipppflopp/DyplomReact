import { combineReducers } from 'redux';
import userReducer from './reducers/userReducer';
import categoriesReducer from './reducers/categoriesReducer';

const rootReducer = combineReducers({
  user: userReducer,
  categories: categoriesReducer
});

export default rootReducer;
