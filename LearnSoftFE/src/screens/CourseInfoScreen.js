import React from 'react';
import {
 RefreshControl, StyleSheet, Text, SafeAreaView, Image, View, FlatList, Dimensions, ToastAndroid, Button
} from 'react-native';
import LogoComponent from './../components/Logo'
import ActionButton from './../components/ActionButton'
import  api from "../api/ApiCaller";


const widthConst = Dimensions.get('screen').width;

export default function CourseInfoScreen({ route, navigation }) {
  const mock = {
  classCycleId: 1,
  studentCount: 30,
  classInfo: {
    courseId: 1,
    name: "IPR",
    ects: 2,
    numberOfHours: 30
  },
  courseAssignments: [
    {
      userId: 1,
      name: "Sebastian",
      surname: "Parzych"
    },
    {
      userId: 4,
      name: "Wiesław",
      surname: "Nowak"
    }
  ]
}

  const host = route.params.user;
  const course = route.params.course;
  const [Data, SetData] = React.useState({});
  const [ClassInfo, SetInfo] = React.useState({});

    React.useEffect(() => {
      api.callGetFullCourseInfo({"courseId":course.courseId})
     .then((response) => response.json())
      .then((responseJson) => {
          SetData(responseJson)
          SetInfo(responseJson.classInfo)
      })
      .catch((error) => {
        alert(error);
      }); 
  }, [])

  function Item({ props }) {
    return (
      <ActionButton
           text = {props.name +" "+ props.surname} 
           onPress={ () =>{navigation.navigate("PersonInfoScreen",{props,host})}}
      ></ActionButton> 

    );
  }
  return (

      <SafeAreaView style = {{flex:1}} >
        <View style={{flex:0.5, alignContent: 'left', justifyContent: 'left',alignItems:'left'}}>
        <LogoComponent header = {ClassInfo.name}/>
        </View>
        <View style = {{flex:0.5,alignContent: 'top', justifyContent: 'top',alignItems:'top', borderWidth:1}}>
          <View>
            <View>
              <Text>
              Punkty ECTS do zdobycia: {ClassInfo.ects}
              </Text>
            </View>
                        <View>
              <Text>
              Ilość godzin: {ClassInfo.numberOfHours}
              </Text>
            </View>
                <View>
              <Text>
              Maksymalna Liczba studentów: {Data.studentCount}
              </Text>
            </View>
          </View>
        </View>
        <View style={{flex:0.1, borderWidth:2}}>
          <Text>
            Uczestnicy
          </Text>
        </View>
        <View style= {{flex:3, alignContent: 'top', justifyContent: 'top',alignItems:'top'}}>
        <FlatList
        data={Data.courseAssignments}
        renderItem={({ item }) => <Item props={item} />}
        contentContainerStyle={styles.list}
          />

        </View>
    </SafeAreaView>

  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  //  color: 'white',
  },
  list: {
    alignItems: 'center',
    justifyContent: 'top',
    width: widthConst,
    flex: 1,
    marginTop : 10,
  },
  enappdWrapper: {
    position: 'absolute',
    bottom: 0
  },

  item: {
    marginTop: 0,
    width: 300,
   // backgroundColor: 'white',
    flexDirection: 'row',
    alignItems: 'flex-start',
    paddingHorizontal: 5,
    padding: 5 ,
    borderWidth: 1, 

  },
  itemText: {
    textAlign: 'center', // <-- the magic
    fontWeight: 'bold',
    fontSize: 24,
    marginTop:20,
    width: 300,
  //  backgroundColor: 'white',

  }
});