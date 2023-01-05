//action creators
const newBooking=(name,amount)=>{
    return {
        type:"NEW_BOOKING",
        payload:{
            name,
            amount
        }
    }
}
const cancelBooking=(name,refamount)=>{
    return {
        type:"CANCEL_BOOKING",
        payload:{
            name,
            refamount
        }
    }
}
//reducers
const reservationHistory=(oldReservationList=[],action)=>{
    console.log("in booking history")
    switch(action.type){
      case "NEW_BOOKING":
        return [...oldReservationList,{...action.payload}] 
        break;
      case "CANCEL_BOOKING":
        return oldReservationList.filter(
            (result)=>{
                return result.name!==action.payload.name
            }
        )
        break;
      default:
            return oldReservationList;  
    
    }
}

const cancellationHistory=(oldCancellationList=[],action)=>{
    console.log("in canceelation history");
    switch(action.type){
        case "CANCEL_BOOKING":
            return [...oldCancellationList,{...action.payload}]
            break;
        default:
            return oldCancellationList;
    }

}

const amoutmanage=(totalMoney=1000,action)=>{
    switch(action.type){
        case "NEW_BOOKING":
          return  totalMoney+action.payload.amount;
         
          break;
        case "CANCEL_BOOKING":
          return totalMoney-action.payload.refamount;
          
          break;
        default:
              return totalMoney; 
    }

}

//create store

console.log("Redux");
const {createStore,combineReducers}=Redux;
const railwayStore=combineReducers({
    amoutmanage:amoutmanage,
    reservationHistory:reservationHistory,
    cancellationHistory:cancellationHistory
});

const store=createStore(railwayStore)

//test store
const action1=newBooking("Rajan",2000);
store.dispatch(action1);
console.log(store.getState());
const action2=newBooking("Revati",3000);
store.dispatch(action2);
console.log(store.getState());
const action3=cancelBooking("Rajan",1000);
store.dispatch(action3);
console.log(store.getState());